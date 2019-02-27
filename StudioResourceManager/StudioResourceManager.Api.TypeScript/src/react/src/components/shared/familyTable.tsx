import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import FamilyMapper from '../family/familyMapper';
import FamilyViewModel from '../family/familyViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';

interface FamilyTableComponentProps {
  id: number;
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
      .get(this.props.apiRoute, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      .then(
        resp => {
          let response = resp.data as Array<Api.FamilyClientResponseModel>;

          console.log(response);

          let mapper = new FamilyMapper();

          let families: Array<FamilyViewModel> = [];

          response.forEach(x => {
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
                Header: 'Families',
                columns: [
                  {
                    Header: 'Notes',
                    accessor: 'note',
                    Cell: props => {
                      return <span>{String(props.original.note)}</span>;
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
                          type="primary"
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
                          type="primary"
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
    <Hash>4e98b6436ccab57cc727c9fb9208ecbd</Hash>
</Codenesium>*/