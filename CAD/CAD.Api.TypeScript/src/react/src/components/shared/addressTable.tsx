import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import AddressMapper from '../address/addressMapper';
import AddressViewModel from '../address/addressViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface AddressTableComponentProps {
  apiRoute: string;
  history: any;
  match: any;
}

interface AddressTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<AddressViewModel>;
}

export class AddressTableComponent extends React.Component<
  AddressTableComponentProps,
  AddressTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: AddressViewModel) {
    this.props.history.push(ClientRoutes.Addresses + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: AddressViewModel) {
    this.props.history.push(ClientRoutes.Addresses + '/' + row.id);
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.AddressClientResponseModel>>(this.props.apiRoute, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new AddressMapper();

        let addresses: Array<AddressViewModel> = [];

        response.data.forEach(x => {
          addresses.push(mapper.mapApiResponseToViewModel(x));
        });

        this.setState({
          ...this.state,
          filteredRecords: addresses,
          loading: false,
          loaded: true,
          errorOccurred: false,
          errorMessage: '',
        });
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);

        if (error.response && error.response.status == 422) {
          this.setState({
            ...this.state,
            errorOccurred: false,
            errorMessage: '',
          });
        } else {
          this.setState({
            ...this.state,
            errorOccurred: true,
            errorMessage: 'Error Occurred',
          });
        }
      });
  }

  render() {
    let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    }

    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.errorOccurred) {
      return <Alert message={this.state.errorMessage} type="error" />;
    } else if (this.state.loaded) {
      return (
        <div>
          {message}
          <ReactTable
            data={this.state.filteredRecords}
            defaultPageSize={10}
            columns={[
              {
                Header: 'Addresses',
                columns: [
                  {
                    Header: 'Address1',
                    accessor: 'address1',
                    Cell: props => {
                      return <span>{String(props.original.address1)}</span>;
                    },
                  },
                  {
                    Header: 'Address2',
                    accessor: 'address2',
                    Cell: props => {
                      return <span>{String(props.original.address2)}</span>;
                    },
                  },
                  {
                    Header: 'City',
                    accessor: 'city',
                    Cell: props => {
                      return <span>{String(props.original.city)}</span>;
                    },
                  },
                  {
                    Header: 'State',
                    accessor: 'state',
                    Cell: props => {
                      return <span>{String(props.original.state)}</span>;
                    },
                  },
                  {
                    Header: 'Zip',
                    accessor: 'zip',
                    Cell: props => {
                      return <span>{String(props.original.zip)}</span>;
                    },
                  },
                  {
                    Header: 'Actions',
                    minWidth: 150,
                    Cell: row => (
                      <div>
                        <Button
                          htmlType="button"
                          onClick={(e: any) => {
                            this.handleDetailClick(
                              e,
                              row.original as AddressViewModel
                            );
                          }}
                        >
                          <i className="fas fa-search" />
                        </Button>
                        &nbsp;
                        <Button
                          htmlType="button"
                          onClick={(e: any) => {
                            this.handleEditClick(
                              e,
                              row.original as AddressViewModel
                            );
                          }}
                        >
                          <i className="fas fa-edit" />
                        </Button>
                      </div>
                    ),
                  },
                ],
              },
            ]}
          />
        </div>
      );
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>7aa2d006b6d53e07542f16d9bf13345f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/