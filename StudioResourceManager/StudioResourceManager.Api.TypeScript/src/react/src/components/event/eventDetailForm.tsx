import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { LoadingForm } from '../../lib/components/loadingForm';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import EventMapper from './eventMapper';
import EventViewModel from './eventViewModel';
import { Form, Input, Button } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Alert } from 'antd';

interface EventDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface EventDetailComponentState {
  model?: EventViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class EventDetailComponent extends React.Component<
  EventDetailComponentProps,
  EventDetailComponentState
> {
  state = {
    model: new EventViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Events + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Events +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.EventClientResponseModel;

          console.log(response);

          let mapper = new EventMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
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
      return <LoadingForm />;
    } else if (this.state.loaded) {
      return (
        <div>
          <Button
            style={{ float: 'right' }}
            type="primary"
            onClick={(e: any) => {
              this.handleEditClick(e);
            }}
          >
            <i className="fas fa-edit" />
          </Button>
          <div>
            <div>
              <div>actualEndDate</div>
              <div>{this.state.model!.actualEndDate}</div>
            </div>
            <div>
              <div>actualStartDate</div>
              <div>{this.state.model!.actualStartDate}</div>
            </div>
            <div>
              <div>billAmount</div>
              <div>{this.state.model!.billAmount}</div>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>eventStatusId</h3>
              <div>
                {this.state.model!.eventStatusIdNavigation!.toDisplay()}
              </div>
            </div>
            <div>
              <div>scheduledEndDate</div>
              <div>{this.state.model!.scheduledEndDate}</div>
            </div>
            <div>
              <div>scheduledStartDate</div>
              <div>{this.state.model!.scheduledStartDate}</div>
            </div>
            <div>
              <div>studentNote</div>
              <div>{this.state.model!.studentNote}</div>
            </div>
            <div>
              <div>teacherNote</div>
              <div>{this.state.model!.teacherNote}</div>
            </div>
          </div>
          {message}
        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedEventDetailComponent = Form.create({
  name: 'Event Detail',
})(EventDetailComponent);


/*<Codenesium>
    <Hash>07f6b144774e35d7a24d959b72a1e769</Hash>
</Codenesium>*/