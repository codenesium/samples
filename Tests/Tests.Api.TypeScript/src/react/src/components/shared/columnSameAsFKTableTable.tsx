import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ColumnSameAsFKTableMapper from '../columnSameAsFKTable/columnSameAsFKTableMapper';
import ColumnSameAsFKTableViewModel from '../columnSameAsFKTable/columnSameAsFKTableViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface ColumnSameAsFKTableTableComponentProps {
  apiRoute: string;
  history: any;
  match: any;
}

interface ColumnSameAsFKTableTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<ColumnSameAsFKTableViewModel>;
}

export class ColumnSameAsFKTableTableComponent extends React.Component<
  ColumnSameAsFKTableTableComponentProps,
  ColumnSameAsFKTableTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: ColumnSameAsFKTableViewModel) {
    this.props.history.push(
      ClientRoutes.ColumnSameAsFKTables + '/edit/' + row.id
    );
  }

  handleDetailClick(e: any, row: ColumnSameAsFKTableViewModel) {
    this.props.history.push(ClientRoutes.ColumnSameAsFKTables + '/' + row.id);
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.ColumnSameAsFKTableClientResponseModel>>(
        this.props.apiRoute,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new ColumnSameAsFKTableMapper();

        let columnSameAsFKTables: Array<ColumnSameAsFKTableViewModel> = [];

        response.data.forEach(x => {
          columnSameAsFKTables.push(mapper.mapApiResponseToViewModel(x));
        });

        this.setState({
          ...this.state,
          filteredRecords: columnSameAsFKTables,
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
                Header: 'ColumnSameAsFKTables',
                columns: [
                  {
                    Header: 'Person',
                    accessor: 'person',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.People + '/' + props.original.person
                            );
                          }}
                        >
                          {String(
                            props.original.personNavigation &&
                              props.original.personNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Person',
                    accessor: 'personId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.People +
                                '/' +
                                props.original.personId
                            );
                          }}
                        >
                          {String(
                            props.original.personIdNavigation &&
                              props.original.personIdNavigation.toDisplay()
                          )}
                        </a>
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
                              row.original as ColumnSameAsFKTableViewModel
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
                              row.original as ColumnSameAsFKTableViewModel
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
    <Hash>eacfdde90cceb8e8a3cb2db7e78d3acd</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/