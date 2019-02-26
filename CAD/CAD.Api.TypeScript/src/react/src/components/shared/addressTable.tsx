import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import AddressMapper from '../address/addressMapper';
import AddressViewModel from '../address/addressViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';

interface AddressTableComponentProps {
  id: number;
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
    this.setState({ ...this.state, loading: true });

    axios
      .get(this.props.apiRoute, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      .then(
        resp => {
          let response = resp.data as Array<Api.AddressClientResponseModel>;

          console.log(response);

          let mapper = new AddressMapper();

          let addresses: Array<AddressViewModel> = [];

          response.forEach(x => {
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
        },
        error => {
          console.log(error);
          this.setState({
            ...this.state,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
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
                    Cell: row => (
                      <div>
                        <Button
                          type="primary"
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
                          type="primary"
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
    <Hash>ca6cc4bb2d18b2313e1be3eca35b6176</Hash>
</Codenesium>*/