import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import UnitOfficerMapper from '../unitOfficer/unitOfficerMapper';
import UnitOfficerViewModel from '../unitOfficer/unitOfficerViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';

interface UnitOfficerTableComponentProps {
  id: number;
  apiRoute: string;
  history: any;
  match: any;
}

interface UnitOfficerTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<UnitOfficerViewModel>;
}

export class UnitOfficerTableComponent extends React.Component<
  UnitOfficerTableComponentProps,
  UnitOfficerTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: UnitOfficerViewModel) {
    this.props.history.push(ClientRoutes.UnitOfficers + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: UnitOfficerViewModel) {
    this.props.history.push(ClientRoutes.UnitOfficers + '/' + row.id);
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
          let response = resp.data as Array<Api.UnitOfficerClientResponseModel>;

          console.log(response);

          let mapper = new UnitOfficerMapper();

          let unitOfficers: Array<UnitOfficerViewModel> = [];

          response.forEach(x => {
            unitOfficers.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: unitOfficers,
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
                Header: 'UnitOfficers',
                columns: [
                  {
                    Header: 'OfficerId',
                    accessor: 'officerId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Officers +
                                '/' +
                                props.original.officerId
                            );
                          }}
                        >
                          {String(
                            props.original.officerIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'UnitId',
                    accessor: 'unitId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Units + '/' + props.original.unitId
                            );
                          }}
                        >
                          {String(props.original.unitIdNavigation.toDisplay())}
                        </a>
                      );
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
                              row.original as UnitOfficerViewModel
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
                              row.original as UnitOfficerViewModel
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
    <Hash>57d24f325c52f23952c3836b7e03c6eb</Hash>
</Codenesium>*/