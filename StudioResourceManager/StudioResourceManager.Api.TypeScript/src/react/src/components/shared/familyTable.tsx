import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import FamilyMapper from '../family/familyMapper';
import FamilyViewModel from '../family/familyViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface FamilyTableComponentProps {
  apiRoute: string;
  history: any;
  match: any;
}

interface FamilyTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<FamilyViewModel>;
}

export class FamilyTableComponent extends React.Component<
  FamilyTableComponentProps,
  FamilyTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: FamilyViewModel) {
    this.props.history.push(ClientRoutes.Families + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: FamilyViewModel) {
    this.props.history.push(ClientRoutes.Families + '/' + row.id);
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.FamilyClientResponseModel>>(this.props.apiRoute, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new FamilyMapper();

        let families: Array<FamilyViewModel> = [];

        response.data.forEach(x => {
          families.push(mapper.mapApiResponseToViewModel(x));
        });

        this.setState({
          ...this.state,
          filteredRecords: families,
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
                Header: 'Families',
                columns: [
                  {
                    Header: 'Notes',
                    accessor: 'notes',
                    Cell: props => {
                      return <span>{String(props.original.notes)}</span>;
                    },
                  },
                  {
                    Header: 'Primary Contact Email',
                    accessor: 'primaryContactEmail',
                    Cell: props => {
                      return (
                        <span>
                          {String(props.original.primaryContactEmail)}
                        </span>
                      );
                    },
                  },
                  {
                    Header: 'Primary Contact First Name',
                    accessor: 'primaryContactFirstName',
                    Cell: props => {
                      return (
                        <span>
                          {String(props.original.primaryContactFirstName)}
                        </span>
                      );
                    },
                  },
                  {
                    Header: 'Primary Contact Last Name',
                    accessor: 'primaryContactLastName',
                    Cell: props => {
                      return (
                        <span>
                          {String(props.original.primaryContactLastName)}
                        </span>
                      );
                    },
                  },
                  {
                    Header: 'Primary Contact Phone',
                    accessor: 'primaryContactPhone',
                    Cell: props => {
                      return (
                        <span>
                          {String(props.original.primaryContactPhone)}
                        </span>
                      );
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
                              row.original as FamilyViewModel
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
                              row.original as FamilyViewModel
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
    <Hash>6fc03ec975fef721183f22ddbbdc40b4</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/